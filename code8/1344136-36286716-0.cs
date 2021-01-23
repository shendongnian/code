    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FileHelpers;
    
    namespace ConvertTXT
    {
        [FixedLengthRecord()]
        
        public class ptMedia
        {
            [FieldFixedLength(16)]
            [FieldTrim(TrimMode.Right)]
            public int id1;
    
            [FieldFixedLength(5)]
            [FieldTrim(TrimMode.Right)]
            public String id2;
    
            [FieldFixedLength(16)]
            [FieldTrim(TrimMode.Right)]
            public string file1;
    
            [FieldFixedLength(16)]
            [FieldTrim(TrimMode.Right)]
            public string file2;
    
            [FieldFixedLength(5)]
            [FieldTrim(TrimMode.Right)]
            public int? id3;
    
            [FieldFixedLength(40)]
            [FieldTrim(TrimMode.Right)]
            public string brand;
    
            [FieldFixedLength(13)]
            [FieldTrim(TrimMode.Right)]
            public string id4;
