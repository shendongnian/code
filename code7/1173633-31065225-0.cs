        public class QA {
             public int QId {get;set;}
             public string Answer {get;set;}
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult RequestSecurityQuestions_Submit(QA[] answers)
        {
            for (var qa in answers){
                 //do what ever you like
            }
        }
