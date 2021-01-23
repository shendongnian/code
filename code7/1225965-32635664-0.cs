    public ActionResult Foo()
            {
                ViewBag.ProcessList = System.Diagnostics.Process.GetProcesses();
                return View();
            }
