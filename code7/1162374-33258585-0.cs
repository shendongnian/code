            string sqlCommand= @"SELECT 
                a.Id StudentId,
                a.Name1 StudentName,
                a.Name2 StudentName2,
                b.Name ClassName,
                c.SchoolName SchoolName 
                    FROM Student a, Class b, School c 
                        WHERE a.ClassID = b.ClassID AND b.SchoolID = c.SchoolID";
    public class StudentInfo
    {
        int StudentId { get; set; }
        string StudentName { get; set; }
        string StudentName2 { get; set; }
        string ClassName { get; set; }
        string SchoolName { get; set; }
    }
            List<StudentInfo> studentInfoList = new List<StudentInfo>();
            studentInfoList = session.CreateSQLQuery(sqlCommand)
                .AddScalar("StudentId", NHibernateUtil.Int32)
                .AddScalar("StudentName", NHibernateUtil.String)
                .AddScalar("StudentName2", NHibernateUtil.String)
                .AddScalar("ClassName", NHibernateUtil.String)
                .AddScalar("SchoolName", NHibernateUtil.String)
                .SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean<StudentInfo>())
                .List<StudentInfo>().ToList();
