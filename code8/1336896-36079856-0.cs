            Debug.WriteLine("Image Upload");
            Task tsk = new Task(() =>
            {
                Thread.Sleep(5000); //This is your UploadSlider Image
                Debug.WriteLine("Done");
            });
            tsk.Start();
            return Json("result", JsonRequestBehavior.AllowGet);
