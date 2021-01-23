    using System;
    using System.Linq;
    using HtmlAgilityPack;
    namespace StackOverFlow
    {
        public class Program
        {
            public static void Main()
            {
                string text =
                    "<p>tset if it work <span onresizestart=\"return false\" ondrag=javascript:dragActif(); contenteditable=false style=\"BACKGROUND-COLOR: #c0d4e6\" edth_type=\"var\" edth_var_pob=\"n\" edth_var_pgm=\"RBLZVALO\" edth_var_def=\"B\" edth_var_casse=\"car\" edth_var_lg=\"050\" edth_var_type=\"c\" edth_var_nom=\"Adr_Leg_Lig1\" edth_var_lib=\"Ligne 1 adresse légale\" edth_var_libc=\"Adr_Leg_Lig1\" edth_var_num=\"1\" edth_var_posfich=\"0\">Adr_Leg_Lig1</span> test</p><p>This <font size=2 edth_sizeutia4=\"8\">should</font> Work</p>";
                HtmlDocument html = new HtmlDocument();
                html.LoadHtml(text);
                var nodes = html.DocumentNode.SelectNodes("//p");
                foreach (
                    var line in
                        nodes.Select(node => node.ChildNodes)
                            .Select(
                                textNodes => textNodes.Aggregate(String.Empty, (current, node) => current + node.InnerText))
                    )
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
