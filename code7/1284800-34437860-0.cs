            bool assigned = false;
            foreach (Supervisor sup in supervisors)
            {
                foreach (Employee emp in employees)
                {
                    if (!sup.SupervisorOccupied)
                    {
                        if (!emp.Busy && emp.Skills.HasFlag(_skillRequired))
                        {
                            assigned = true;
                            emp.EmployeeWorkload = _jobName;
                            emp.ShiftsLeft = _shiftsLeft;
                            emp.Busy = true;
                            sup.EmployeeWorkload = "Supervising Employee: " + emp.EmployeeName + " to finish task: " + emp.EmployeeWorkload;
                            sup.ShiftsLeft = _shiftsLeft;
                            sup.SupervisorOccupied = true;
                            break;
                        }
                    }
                }
                if (assigned)
                    break;
            }
