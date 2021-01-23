        public void DeleteParameterNode(ObservableCollection<ParameterNodeEntity> collection, string path)
        {
            foreach (var item in collection.Where(i => i.Path == path))
            {
                collection.Remove(item);
            }
        }
