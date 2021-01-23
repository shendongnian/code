    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DICTFormsControls dictFormcontrols = new DICTFormsControls();
                dictFormcontrols.Add(controlnm,parentfrm,controlid,controlpermission)
            }
        }
        public class DICTFormsControls
        {
            public static Dictionary<int, DICTFormsControls> dict = new Dictionary<int, DICTFormsControls>();
            public string controlnm { get; set;}
            public string parentfrm { get; set;}
            public int controlid { get; set;}
            public bool controlpermission {get;set;}
            public void Add(string controln, string parentfrm, int controlid, bool controlpermission)
            {
                dict.Add(controlid, new DICTFormsControls() { controlnm = controlnm, parentfrm = parentfrm, controlid = controlid, controlpermission = controlpermission });
            }
        }
    }
    ​
