        public static List<SubOutPut> ChildList = new List<SubOutPut>();
        private void Form3_Load(object sender, EventArgs e)
        {
            List<Student> std = loaddataFull();
            List<Parent> prnt = loaddataParent();
            List<OutPut> MenuItems = new List<OutPut>();
            foreach (Parent id in prnt)
            {
                
                int pid=Convert.ToInt32(id.pID);
                
                //Adding Parent Values to the List
                List<SubOutPut> SubMenuItems = new List<SubOutPut>();
                MenuItems.Add(new OutPut()
                {
                    mID=Convert.ToInt32(id.pID),
                    mParentID=Convert.ToInt32(id.pParentID),
                    mTitle=Convert.ToString(id.pTitle),
                });
             SubMenuItems = GetChildrens(pid);
                foreach (SubOutPut Add in SubMenuItems)
                    {
                        MenuItems.Add(new OutPut()
                        {
                            mID = Convert.ToInt32(Add.SubsmID),
                            mParentID = Convert.ToInt32(Add.SubsmParentID),
                            mTitle = Convert.ToString(Add.SubsmTitle)
                        });
               }
                SubMenuItems.Clear();
            }
            
            dataGridView1.DataSource = MenuItems;
            foreach (var item in MenuItems)
            {
                listView1.Items.Add(item.mID.ToString());
                listView1.Items.Add(item.mParentID.ToString());
                listView1.Items.Add(item.mTitle.ToString());
                listView1.View = View.Tile;
                
            }
           
            dataGridView2.DataSource = loaddataParent();
        }
