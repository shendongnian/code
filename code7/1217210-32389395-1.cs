    myDB dbCon = new myDB();   
    [HttpGet]
    public ActionResult NewLogin()
    {
      // Initialize the model and assign the SelectList
      LoginModel model = new LoginModel()
      {
        QuestionList = SelectList(dbCon.GetQuestion(), "ID", "Value")
      };
      return View(model);
    }
    [HttpPost]
    public ActionResult NewLogin(LoginModel model)
    {
      // Save the user and get their ID
      // Save the values of UserID, Question1, Answer1 
      // and UserID, Question2, Answer2 to your Answers table
    }
