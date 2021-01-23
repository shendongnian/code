    private URI videoAddress=new URI("C:\video.wmv");
    public URI VideoAddress
    {
       get { return videoAddress; }
       set
       {
           videoAddress = value; 
           OnPropertyChanged("LeafName");
       }
    }
