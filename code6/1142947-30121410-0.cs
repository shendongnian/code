    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace Tools
    {
        /// <summary>
        /// набор утилит для форматирования HTML текста
        /// </summary>
        public static class HtmlFormatHelper
        {
            private static Regex _regexLineBreak;
            private static Regex _regexStripFormatting;
            private static Regex _regexTagWhiteSpace;
            private static Regex _regexHyperlink;
    
            /// <summary>
            /// статический конструктор
            /// </summary>
            static HtmlFormatHelper()
            {
                _regexLineBreak = new Regex(@"<(br|BR|p|P)\s{0,1}\/{0,1}>\s*|</[pP]>", RegexOptions.Singleline);
                _regexStripFormatting = new Regex(@"<[^>]*(>|$)", RegexOptions.Singleline);
                _regexTagWhiteSpace = new Regex(@"(>|$)(\W|\n|\r)+<", RegexOptions.Singleline);
                _regexHyperlink = new Regex(@"<a\s+[^>]*href\s*=\s*[""']?([^""'>]+)[""']?[^>]*>([^<]+)</a>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            }
    
            /// <summary>
            /// конвертировать HTML в текст
            /// </summary>
            /// <param name="html"> HTML </param>
            /// <returns></returns>
            public static string HtmlToPlainText(string html)
            {
                var text = html;
    
                text = System.Net.WebUtility.HtmlDecode(text);
                text = _regexTagWhiteSpace.Replace(text, "><");
                text = _regexLineBreak.Replace(text, Environment.NewLine);
                text = _regexStripFormatting.Replace(text, string.Empty);
    
                return text;
            }
    
            /// <summary>
            /// конвертировать HTML в текст с "умным" оформлением
            /// </summary>
            /// <param name="html"> HTML </param>
            /// <returns></returns>
            public static string HtmlToPlainTextSmart(string html)
            {
                // обрабатываем ссылки
                html = _regexHyperlink.Replace(html, e =>
                {
                    string url = e.Groups[1].Value.Trim();
                    string text = e.Groups[2].Value.Trim();
    
                    if (url.Length == 0 || string.Equals(url, text, StringComparison.InvariantCultureIgnoreCase))
                    {
                        // ссылки идентичны или ссылка отсутствует
                        return e.Value;
                    }
                    else
                    {
                        // ссылки отличаются
                        return string.Format("{0} ({1})", text, url);
                    }
                });
    
                return HtmlToPlainText(html);
            }
    
            /// <summary>
            /// кодировать HTML код с "мягком" режиме
            /// </summary>
            /// <param name="html"> HTML </param>
            /// <returns></returns>
            public static string SoftHtmlEncode(string html)
            {
                if (html == null)
                {
                    return null;
                }
                else
                {
                    StringBuilder sb = new StringBuilder(html.Length);
    
                    foreach (char c in html)
                    {
                        if (c == '<')
                        {
                            sb.Append("&lt;");
                        }
                        else if (c == '>')
                        {
                            sb.Append("&gt;");
                        }
                        else
                        {
                            sb.Append(c);
                        }
                    }
    
                    return sb.ToString();
                }
            }
        }
    }
