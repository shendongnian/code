        public HtmlString RenderList(this HtmlHelper htmlHelper, IEnumerable<HtmlListItem> list, object uListHtmlAttributes)
            {
                TagBuilder ul = new Tagbuilder("ul");
                IDictionary<string, object> uListAttributes = new RouteValueDictionary(uListHtmlAttributes);
                ul.MergeAttributes(uListAttributes);
                StringBuilder builder = new StringBuilder();
                builder.Append(ul.ToString(TagRenderMode.StartTag) + Environment.NewLine);
                foreach (var item in list) 
                {
                    TagBuilder hold = new TagBuilder("li");
                    IDictionary<string, object> htmlAttributes = new RouteValueDictionary(item.HtmlAttributes);
                    hold.MergeAttributes(htmlAttributes);
                    hold.InnerHtml = item.Content;
                    builder.Append(hold.ToString(TagRenderMode.Normal) + Environment.NewLine);
                }
                
                builder.Append("</ul>" + Environment.NewLine);
                return new HtmlString(builder.ToString());
            }
