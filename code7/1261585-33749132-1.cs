    class ViewModel
    {
        public ObservableCollection<MarkerClass> Markers { get; set; }
        public ObservableCollection<LayerClass> Layers { get; set; }
        public ViewModel()
        {
            Markers = new ObservableCollection<MarkerClass>();
            Layers = new ObservableCollection<LayerClass>();
            Layers.CollectionChanged += _LayerCollectionChanged;
            for (int j = 0; j < 10; j++)
            {
                var Layer = new LayerClass();
                for (int i = 0; i < 10; i++)
                {
                    Layer.Markers.Add(new MarkerClass(i * 20, 10 * j));
                }
                Layers.Add(Layer);
            }
        }
        private void _LayerCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            ObservableCollection<LayerClass> layers = (ObservableCollection<LayerClass>)sender;
            switch (e.Action)
            {
            case NotifyCollectionChangedAction.Add:
                _InsertMarkers(layers, e.NewItems.Cast<LayerClass>(), e.NewStartingIndex);
                break;
            case NotifyCollectionChangedAction.Move:
            case NotifyCollectionChangedAction.Replace:
                _RemoveMarkers(layers, e.OldItems.Count, e.OldStartingIndex);
                _InsertMarkers(layers, e.NewItems.Cast<LayerClass>(), e.NewStartingIndex);
                break;
            case NotifyCollectionChangedAction.Remove:
                _RemoveMarkers(layers, e.OldItems.Count, e.OldStartingIndex);
                break;
            case NotifyCollectionChangedAction.Reset:
                Markers.Clear();
                break;
            }
        }
        private void _RemoveMarkers(ObservableCollection<LayerClass> layers, int count, int removeAt)
        {
            int removeMarkersAt = _MarkerCountForLayerIndex(layers, removeAt);
            while (count > 0)
            {
                LayerClass layer = layers[removeAt++];
                layer.Markers.CollectionChanged -= _LayerMarkersCollectionChanged;
                Markers.RemoveRange(removeMarkersAt, layer.Markers.Count);
            }
        }
        private void _InsertMarkers(ObservableCollection<LayerClass> layers, IEnumerable<LayerClass> newLayers, int insertLayersAt)
        {
            int insertMarkersAt = _MarkerCountForLayerIndex(layers, insertLayersAt);
            foreach (LayerClass layer in newLayers)
            {
                layer.Markers.CollectionChanged += _LayerMarkersCollectionChanged;
                Markers.InsertRange(layer.Markers, insertMarkersAt);
                insertMarkersAt += layer.Markers.Count;
            }
        }
        private void _LayerMarkersCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ObservableCollection<MarkerClass> markers = (ObservableCollection<MarkerClass>)sender;
            int layerIndex = _GetLayerIndexForMarkers(markers);
            switch (e.Action)
            {
            case NotifyCollectionChangedAction.Add:
                Markers.InsertRange(e.NewItems.Cast<MarkerClass>(), _MarkerCountForLayerIndex(Layers, layerIndex));
                break;
            case NotifyCollectionChangedAction.Move:
            case NotifyCollectionChangedAction.Replace:
                Markers.RemoveRange(layerIndex, e.OldItems.Count);
                Markers.InsertRange(e.NewItems.Cast<MarkerClass>(), _MarkerCountForLayerIndex(Layers, layerIndex));
                break;
            case NotifyCollectionChangedAction.Remove:
            case NotifyCollectionChangedAction.Reset:
                Markers.RemoveRange(layerIndex, e.OldItems.Count);
                break;
            }
        }
        private int _GetLayerIndexForMarkers(ObservableCollection<MarkerClass> markers)
        {
            for (int i = 0; i < Layers.Count; i++)
            {
                if (Layers[i].Markers == markers)
                {
                    return i;
                }
            }
            throw new ArgumentException("No layer found with the given markers collection");
        }
        private static int _MarkerCountForLayerIndex(ObservableCollection<LayerClass> layers, int layerIndex)
        {
            return layers.Take(layerIndex).Sum(layer => layer.Markers.Count);
        }
    }
    static class Extensions
    {
        public static void InsertRange<T>(this ObservableCollection<T> source, IEnumerable<T> items, int insertAt)
        {
            foreach (T t in items)
            {
                source.Insert(insertAt++, t);
            }
        }
        public static void RemoveRange<T>(this ObservableCollection<T> source, int index, int count)
        {
            for (int i = index + count - 1; i >= index; i--)
            {
                source.RemoveAt(i);
            }
        }
    }
