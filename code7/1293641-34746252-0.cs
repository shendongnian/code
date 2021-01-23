        protected void Page_Load(object sender, EventArgs e)
            {
                 if (Page.IsPostBack == false)
                {
                     LoadStickies();
                }
            }
    
        private void LoadStickies() {
                // Current user id
                String id= Request.QueryString["id"]; 
    
                // Get stickies from current user
                List<Sticky> stickies = Database.getStickies(id); 
    
                // Load stickies to screen
                foreach(Sticky s in stickies)
                {
                   StickyControl stickyControl = (StickyControl)LoadControl("StickyControl.ascx");
                   stickyControl.Text= s.Text;
                   stickyControl.Id = s.Id;
                   panelStickies.Controls.Add(stickyControl);
                }
    
        }
    
          protected void btnDeleteSticky_Click(object sender, EventArgs e)
           {
              Database.deleteSticky(Id);   
              LoadStickies();        
           }
