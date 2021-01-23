     protected void Page_Load(object sender, EventArgs e)
            {
              if(Page.IsPostBack)
               {
                 CreateControls(YourCollectionInSession)
               }
            }
     protected void Timer1_Tick(object sender, EventArgs e)
            {
                CreateControl();
            }
     void CreateControl()
            {
                Button btn1 = new Button();
                btn1.ID = "btn" + yourSessionID;
                btn1.Text = "click me";
                btn1.Click += new EventHandler(btn1_Click);
                div1.Controls.Add(btn1);
                yourSessionID++;
                YourCollectionInSession.Add(btn1);
            }
     void CreateControl(List<Button> buttons)
            {
                foreach(Button btn in buttons)
                {
                div1.Controls.Add(btn); 
                }
            }
