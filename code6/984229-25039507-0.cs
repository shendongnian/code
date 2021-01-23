    public JsonResult directory()
            {
                
    
                List<string> alp = new List<string>();
                var alp1 = new List<directories>();
                string array = "";
                int a = 0;
                for (a = 0; a <= 25; a++)
                {
                    int unicode = a + 65;
                    char character = (char)unicode;
                    string text1 = character.ToString();
                    string url1 = "<a href='/Directories/?search=" + text1 + "' 'rel=" + text1 + "'>";
                    string alpha = text1;
                    alp.Add(url1);
                    alp.Add(alpha);
                    alp1.Add(new directories { dirurl = url1, text = alpha });
                }
                
                return Json(alp1, JsonRequestBehavior.AllowGet);
            }
    
    
            public class directories
            {
                
                public string text { get; set; }
                public string dirurl { get; set; }
            }
    
    
        }
    }
