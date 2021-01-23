    //Check which steps to disable
                if (role.Contains("Data"))
                {
                    disabledSteps = new int[] {5, 5};
                }
                else if (role.Contains("Infra"))
                {
                    disabledSteps = new int[] {4, 5};
                }
                else if (role.Contains("Security"))
                {
                    disabledSteps = new int[] { 4, 4 };
                }
