    List<Actual> query = (from r in db.RPM_Data
                        where r.Year == DateTime.UtcNow.Year && lines.Contains(r.Budget_Code)
                        group r by new { r.Budget_Code, r.Code_IAM, r.Direction_ID } into grp
                        select
                            new Actual
                            {
                               BudgetLine = grp.Key.Budget_Code,
                               CodeIam = grp.Key.Code_IAM,
                               //Direction = ... -> leave this property unset.                       
                               Direction_ID = grp.Key.Direction_ID, // but set the id.        
                            }
                        ).ToList();
