        /// <summary>
        /// Returns Base64 string of image content. Without redownloading image. If it is not on the same domain, WebSecurity must be set to false.
        /// </summary>
        /// <param name="getElementQuery">
        /// <para>Any Javascript query to get an element.</para>
        /// <para>Examples:</para>
        /// <para>"document.getElementById('id')"</para>
        /// <para>"document.getElementsByClassName('name')[0]"</para>
        /// <para>"document.evaluate(\"//a[contains(@href, 'something')]\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null ).singleNodeValue" (XPath)</para>
        /// </param>
        /// <param name="leaveOnlyBase64Data">if true, removes "data:image/type;base64," from the beginning of the string</param>
        /// <returns>Base64 string or empty string in case of error</returns>
        public static string JsGetImgBase64String(string getElementQuery, bool leaveOnlyBase64Data = true)
        {
            string data = webView.ExecuteJavascriptWithResult(@"
                                            function getImgBase64String(img)
                                            {
                                                var cnv = document.createElement('CANVAS');
                                                var ctx = cnv.getContext('2d');
                                                ctx.drawImage(img, 0, 0);
                                                return cnv.toDataURL();
                                            }
                                " + String.Format("getImgBase64String({0});", getElementQuery));
            if (data == "undefined")
                return string.Empty;
            if (leaveOnlyBase64Data && data.Contains(","))
            {
                data = data.Substring(data.IndexOf(",") + 1);
            }
            return data;
        }
