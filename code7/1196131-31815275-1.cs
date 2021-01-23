        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Publish([Deserialize] PublishViewModel publish, IStepViewModel step)
        {
            publish.Steps[publish.CurrentStepIndex] = step;
            
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(Request["next"]))
                    publish.CurrentStepIndex++;
                else if (!string.IsNullOrEmpty(Request["prev"]))
                    publish.CurrentStepIndex--;
            }
            else if (!string.IsNullOrEmpty(Request["prev"]))
            {
                publish.CurrentStepIndex--;
            }
            if (publish.Steps[publish.CurrentStepIndex].GetType() == typeof(Step1ViewModel))
            {
                var model = publish.Steps[publish.CurrentStepIndex] as Step1ViewModel;
                // Do some magic
            }
            else if (publish.Steps[publish.CurrentStepIndex].GetType() == typeof(Step2ViewModel))
            {
                var model = publish.Steps[publish.CurrentStepIndex] as Step2ViewModel;
                // Do some magic
            }
            return View(publish);
        }
