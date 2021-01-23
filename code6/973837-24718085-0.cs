    public FieldMapControlViewModel(IEnumerable<Field> Fields)
                {
                    FieldPolys = new ObservableCollection<FieldPoly>();
                    foreach (var f in Fields)
                    {
                        FieldPolys.Add(new FieldPoly(this, f,System.Windows.Media.Brushes.Red));
                        
                    }
    
                }
