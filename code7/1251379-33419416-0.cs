    public ActionResult Custom(RoleEnum userRole)
    {
        switch(userRole)
        {
            case RoleEnum.Admin:
            .....
            return Partial("_adminPartial", viewModel);
            
           // rest of you cases here
        }
    }
