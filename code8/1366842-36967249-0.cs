    string ColorValue="your Color String";
              Color col;
              try
              {
                  col = ColorTranslator.FromHtml(ColorValue);
    
    
              }
              catch
              {
                  ColorValue = ColorValue.ToLower();
                  Array Colors=Enum.GetValues(typeof(KnownColor));
                  string[] names=Enum.GetNames(typeof(KnownColor));
                  for (int k = 0; k < Colors.Length; k++)
                  {
                      if (names.Equals(ColorValue))
                      {
    
                          col = Color.FromKnownColor((KnownColor)Colors.GetValue(k));
                      }
    
    
                  }
              }
            }
