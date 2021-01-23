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
                List<ChapterCodeValidationOutput> _validChapterCodeLst = new List<ChapterCodeValidationOutput>() {
                    new ChapterCodeValidationOutput() { chpt_cd =  "07038", appl_src_cd = "C062"},
                    new ChapterCodeValidationOutput() { chpt_cd =  "06206", appl_src_cd = "C191"}
                };
                List<string> _chapterCodes = new List<string>() { "07038" };
                var results = _validChapterCodeLst.Where(x => !_chapterCodes.Contains(x.chpt_cd)).Select(y => new { chpt_cd = y.chpt_cd, appl_src_cd = y.appl_src_cd}).ToList();
            }
        }
        public class ChapterCodeValidationOutput
        {
            public string chpt_cd { get; set; }
            public string appl_src_cd { get; set; }
        }
    }
