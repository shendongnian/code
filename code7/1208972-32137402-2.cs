    string GetDate(string path) {
    
    try
                                            {
    
                                            Bitmap MyPhoto = new Bitmap(file);
                                            const int IDDateTimeOriginal = 36867;
                                            PropertyItem TakenDate = MyPhoto.GetPropertyItem(IDDateTimeOriginal);
                                            Encoding ascii = Encoding.ASCII;
                                            return ascii.GetString(TakenDate.Value, 0, TakenDate.Len - 1);
                                            }
    
    
                                            catch //(ArgumentException) if the property doesn't exists
                                            {
                                              return "MISSING ENTRY";
                                            }
    }
