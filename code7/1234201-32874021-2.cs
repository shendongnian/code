     public String FullName {
         set {
             Int32 spaceIdx = value.IndexOf(" ");
             if( spaceIdx == -1 ) {
                 this.FirstName = value;
                 this.LastName  = "";
             }
             else
             {
                 this.FirstName = value.Substring(0, spaceIdx);
                 this.LastName  = value.Substring(spaceIdx + 1);
             }
         }
     }
