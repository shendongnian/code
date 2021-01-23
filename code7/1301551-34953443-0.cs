     if (enroll.ClassId != enrollDetail.ClassId && enroll.GroupId != enrollDetail.GroupId)
                        {
                            foreach (EnrollmentSubject obj in enrolllist)
                            {
                                
                                enroll.EnrollmentSubjects.Remove(obj);
                                em.EnrollmentSubjects.Remove(obj);
                            }
                        }
