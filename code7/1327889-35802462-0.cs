    class CoordGeom
    {
        public List<object> Items;
    
        List<Curve> _curves;
        public List<Curve> Curves
        {
            get 
            { 
                return _curves ?? (_curves = Items
                    .Where(item => item is Curve).Select(curve => (Curve)curve).ToList()); 
            }
        }
    }
