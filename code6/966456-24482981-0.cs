    public ActionResult Contact()
    {
        SomeViewModel vm = new SomeViewModel();
        vm.Questions = workflow.GetQuestions().ToList();
        vm.Answers = workflow.GetPossibleAnswers();
        return View(vm);//populated radio group
    }
    [HttpPost]
    public ActionResult SendForm(FormCollection form)
    {
        if (String.IsNullOrEmpty(form["FullName"]))
        {
            ModelState.AddModelError("FullName", "Must enter a name,");
            SomeViewModel vm = new SomeViewModel();
            vm.Questions = workflow.GetQuestions().ToList();
            vm.Answers = workflow.GetPossibleAnswers();
            return View(vm);//populated radio group
        }
    //more code…
    }
    public class SomeViewModel : RegisterExternalLoginModel
    {
    public List<Question> Questions { get; set; }
    public IList<Answer> PossibleAnswers { get; set; }
    public List<SelectedAnswer> SelectedAnswers { get; set; }
    public IList<SelectedAnswer> PreviousAnswers 
    { 
        set 
        { 
            foreach(Question q in Questions)
            {
                q.SelectedAnswers = value.Where(t => t.questionId == q.objectId).ToList() ;
            }
        } 
    }
    }
