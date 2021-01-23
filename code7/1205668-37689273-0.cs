    //In my EnityModels folder is where I keep my POCO classes
    //Nice and clean class
    public class Model
    {
        public int ModelID { get; set; }
        public string ModelName { get; set; }
        public int ModelSSN {get; set; }
        public virtual ICollection<Language> Languages { get; set; }
    }
    /*Then in another folder called ModelVMs you would have your ViewModels
      ViewModels are usually not mapped to the Database
      I like to have a Constructor that does the data transfer for me
    
      This is also where I keep my methods as well as my property validation
      FYI: I also keep Flags and View Specific Properties in my ViewModel*/
    public class ModelVM  //or ModelViewModel
    {
        public ModelVM() { }
        public ModelVM(Model model)
        {
            this.ModelVMID = model.ModelID;    //yes the "this" in this example is unnecessary
            this.ModelVMName = model.ModelName;
            this.ModelVMSSN = model.ModelSSN;
            foreach(var lang in model.Languages)
            {
                this.SLLanguages.Add(new SelectListItem() 
                                        { 
                                            Text = lang.LanguageName, 
                                            Value = lang.LanguageID
                                        }
                                    );
            }
        }
        [Required]
        public int ModelVMID {get; set; }
        [Required]
        [Display(Name="Model Name")]
        public string ModelVMName {get; set; }
        [Required]
        [Display(Name="We need your Social Security Number")]
        public int ModelSSN {get; set; }
    /****************View Specific Properties****************************/
    public SelectList SLLanguages { get; set; }
    }
