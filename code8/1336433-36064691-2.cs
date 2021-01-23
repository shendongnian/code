            var subjectGroups = from subjectStudent in list
                                group subjectStudent by subjectStudent.Subject;
            foreach(var subjectNameGroup in subjectGroups)
            {
                int id = 0;
                foreach (var studentSubject in subjectNameGroup)
                {
                    studentSubject.ID = id;
                    id++;
                }
            }
