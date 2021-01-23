    class CustomMarker: GMapMarker
    {
        public string Description { get; set; }
    
        public CustomMarker(PointLatLng pos, string description)
                : base(pos)
        {
            Description = description;
            Shape = new CustomMarkerElement();
    
            ((CustomMarkerElement)Shape).lblDesc.Content = description;            
        }
    }
