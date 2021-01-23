    public class MapperGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FullEntityName">Entity Name in  DataBase Contain NameSpace</param>
        /// <param name="ServiceModelName"></param>
        /// <param name="MapperFunctionName"></param>
        /// <param name="NeedHtmlBreak"></param>
        /// <returns></returns>
        public string GenerateMapperString(string FullEntityName, string ServiceModelName, string MapperFunctionName, bool NeedHtmlBreak)
        {
            List<string> PropNames = new List<string>();
            var names = new ECBVendorDAL.DataMapperGenerator().GetServiceModelProprty(FullEntityName);
            PropNames.AddRange(names);
            // DB Entity
            string EntityName = FullEntityName.Split('.')[1];
            //Service Model
            string B_SM = ServiceModelName;
            // Function In Mapper
            string strFunc = MapperFunctionName;
            StringBuilder sb = new StringBuilder();
            // A>B
            sb.Append(GetModelString(PropNames, EntityName, ServiceModelName, strFunc, NeedHtmlBreak, false));
            // B>A
            sb.Append(GetModelString(PropNames, ServiceModelName, EntityName, strFunc, NeedHtmlBreak, false));
            //List<A> to List<B>
            sb.Append(GetModelString(PropNames, EntityName, ServiceModelName, strFunc, NeedHtmlBreak, true));
            //List<B> to List<A>
            sb.Append(GetModelString(PropNames, ServiceModelName, EntityName, strFunc, NeedHtmlBreak, true));
            return sb.ToString();
        }
        private string GetModelString(List<string> ColunNames, string ReturnedClass, string PassedClass, string strFunctionName, bool ApplyHtmlBr, bool IsList = false)
        {
            string htmlBr = ApplyHtmlBr ? "<br />" : string.Empty;
            StringBuilder Sb = new StringBuilder();
            if (IsList)
            {
                #region dbModelName To dbServiceModelName
                //public static List<VendorServiceModel> GetVendorServiceModel(ICollection<ECB_Vendor> input)
                Sb.Append("<xmp>");
                Sb.Append(string.Format("public static List<{0}> {2}(ICollection<{1}> input)", ReturnedClass, PassedClass, strFunctionName));
                Sb.Append("</xmp>" + htmlBr);
                Sb.Append("{" + htmlBr);
                // -    -   -   -   - List<VendorServiceModel> result = new List<VendorServiceModel>();
                Sb.Append("<xmp>");
                Sb.Append(string.Format(" List<{0}> result = new List<{0}>();", ReturnedClass));
                Sb.Append("</xmp>" + htmlBr);
                Sb.Append("foreach (var item in input)" + htmlBr);
                Sb.Append("{" + htmlBr);
                Sb.Append("<xmp>");
                Sb.Append(string.Format("result.Add({0}(item));", strFunctionName));
                Sb.Append("</xmp>" + htmlBr);
                Sb.Append("}" + htmlBr);
                Sb.Append("return result;" + htmlBr);
                Sb.Append("}" + htmlBr);
                #endregion
            }
            else
            {
                #region One - PassedClass To ReturnedClass
                Sb.Append(htmlBr);
                Sb.Append(string.Format("public static {0} {2}({1} input)" + htmlBr, ReturnedClass, PassedClass, strFunctionName));
                Sb.Append("{" + htmlBr);
                Sb.Append(string.Format("return new {0}()", ReturnedClass));
                Sb.Append("{" + htmlBr);
                foreach (var item in ColunNames)
                {
                    Sb.Append(string.Format("{0} = input.{0} , " + htmlBr, item));
                }
                Sb.Append("};" + htmlBr);
                Sb.Append("}" + htmlBr);
                Sb.Append(htmlBr);
                #endregion
            }
            return Sb.ToString();
        }
    }
