    using System;
    using Skillgun;
    namespace WcfService1
    {
        // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
        // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
        public class Skillgun_App : ISkillgun_App
        {
            public ChapterNames[] Chapters_Names(string sub_topic_id)
            {
                throw new NotImplementedException();
            }
            public Paper_Ids[] Paper_ids(string chapter_id)
            {
                throw new NotImplementedException();
            }
            public Qtions_data[] Qtions_data(string paper_id)
            {
                throw new NotImplementedException();
            }
        }
    }
