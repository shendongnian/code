        if (!Page.IsPostBack)
          {
             CustomRadioButton rb = (CustomRadioButton)e.Item.FindControl("CustomRadioButtonID");
             rb.OnCheckedChanged += new EventHandler(RadioButton_Selected_OnCheckedChanged);
          }
