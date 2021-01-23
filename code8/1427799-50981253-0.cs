    private void AddErrors(IdentityResult result)
            {
                foreach (var error in result.Errors)
                {
                    string errorMessage = error;
                    if (error.EndsWith("is already taken."))
                    {
                        errorMessage = "This email id is alreday registered !";
                        ModelState.AddModelError("", errorMessage);
                        break;
                    }
                    ModelState.AddModelError("", error);
                }
            }
