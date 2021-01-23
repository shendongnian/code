        public UIControl FindText(UIControl ui)
        { 
          UIControl returnControl = null;
          IEnumerator<UITestControl> UIItemTableChildEnumerator =
          ui.GetChildren().GetEnumerator();
        
          while(uiChildEnumerator.MoveNext())
          {
               if(uiChildEnumerator.Current.DisplayText.equals(StringName))
               {
                   returnControl = uiChildEnumerator.Current  
                   break;
               }
               else
               {
                   returnControl = this.FindText(uiChildEnumerator.Current)
                   if(returnControl != null)
                   {
                       break;
                   }
               }
          }
 
          return returnControl;
        }
 
