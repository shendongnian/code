       private string _image;
       public string Image
       {
          get { return _image; }
          set { 
              _image = value;
              // you might have to do some tweaking on this code below to get it to work...
              var id = Resources.GetIdentifier(value, "drawable", PackageName);
              SetImageResource(id);
          }
       }
