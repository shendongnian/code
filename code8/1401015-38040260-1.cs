    var query = semesters.Join(semestersbyfaculty,
                                    sem => sem.ID,
                                    fac => fac.SemesterID,
                                    (sem, fac) =>
                                        new { facName = fac.FacultyName, facId = fac.FacultyID,semText = sem.SemesterText }).Where(e=> e.fac.FacultyId = id);
