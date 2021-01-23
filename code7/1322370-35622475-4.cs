     public ActionResult Test()
            {
                MyViewModel myViewModel = new MyViewModel()
                {
                    Registertable = new Table(),
                    UserList = new List<Table>(){
                        new Table(){
                            name="xyz",
                            id=1
                        },
                        new Table(){
                            name="ABC",
                            id=2
                        }
                    }
                };
                return View(myViewModel);
            }
