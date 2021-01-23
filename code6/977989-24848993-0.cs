        public void LoginToFaceBook(System.Windows.Forms.HtmlDocument doc, string email, string password)
        {
            //<input name="email" tabindex="1" class="inputtext" id="email" type="text" value="">
            doc.GetElementById("email").SetAttribute("value", email);
            //<input name="pass" tabindex="2" class="inputtext" id="pass" type="password">
            doc.GetElementById("pass").SetAttribute("value", password);
            //<input tabindex="4" id="u_0_n" type="submit" value="Log In">
            doc.GetElementById("u_0_n").InvokeMember("click");
        }
        
        /// <remarks>Should be logged-in to call this method</remarks>
        public void LogOutFromFaceBook(System.Windows.Forms.HtmlDocument doc)
        {
            // <input class="uiLinkButtonInput" type="submit" value="Log Out" />
            (from tag in doc.GetElementsByTagName("input").OfType<System.Windows.Forms.HtmlElement>()
             where tag.GetAttribute("className") == "uiLinkButtonInput" &&
                           tag.GetAttribute("type") == "submit" &&
                           tag.GetAttribute("value") == "Log Out"
                     select tag).First().InvokeMember("click");           
        }
