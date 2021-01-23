    using System.Web;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Newtonsoft.Json;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.IO;
    using IoFile = System.IO.File; //this
    using System.Text;
    
    //in your method
    using (var reader = IoFile.CreateText(@"C:\inetpub\wwwroot\procedimiento.txt"))
