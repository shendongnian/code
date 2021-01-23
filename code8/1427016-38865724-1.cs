        [XmlIgnoreAttribute()]
        public System.Drawing.Image diagramImage { get; set; }
        // Serializes the 'Picture' Bitmap to XML.
        [XmlElementAttribute("diagramImage")]
        public string imageBase64String
        {
            get
            {
                if (this.diagramImage != null)
                {
                    
                    System.ComponentModel.TypeConverter BitmapConverter = System.ComponentModel.TypeDescriptor.GetConverter(this.diagramImage.GetType());
                    byte[] byteArray = (byte[])BitmapConverter.ConvertTo(this.diagramImage, typeof(byte[]));
                    string imageString = Convert.ToBase64String(byteArray);
                    return imageString;
                }
                else
                    return null;
            }
            set
            {
                if (value != null)
                {
                    byte[] imageFileBytes = Convert.FromBase64String(value);
                    this.diagramImage = new System.Drawing.Bitmap(new System.IO.MemoryStream(imageFileBytes));
                }
                else
                {
                    this.diagramImage = null;
                }
            }
        }
