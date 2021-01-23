    void Main()
    {
    	var xml = @"<?xml version=""1.0"" encoding=""utf - 8""?>
       <projects>
         <project>
           <details>
             <projectName><![CDATA[CxWtGZxYT]]></projectName>
             <uniqueID> Pt144 </uniqueID>
             <collaboratingList>
               <collaboratingOrganisation id = ""5318"" value = ""EpCyxCv RvGxrXAYXGpA xCxWtGZxYT"" />
    	          <collaboratingOrganisation id = ""0000"" value = ""EpCyxCv RvGxrXAYXGpA xCxWtGZxYTd"" />
    		       </collaboratingList>
    		       <researchOutputList>
    		         <item>
    		           <pubDate>2014-02-04T00:00:00+00:00</pubDate>
    				             <title><![CDATA[rGDEZ]]></title>
    				             <link> link </link>
    				             <guid> guid </guid>
    				             <description><![CDATA[uGDB BDstA rGDEZ]]></description>
    				           </item>
    				           <item>
    				             <pubDate>2015-08-04T00:00:00+00:00</pubDate>
                                           <title><![CDATA[AERx CApCYZ.]]></title>
                                           <link> link </link>
                                           <guid> guid </guid>
                                           <description><![CDATA[vwtpY]]></description>
                                         </item>
                                       </researchOutputList>
                                     </details>
                                   </project>
                                 </projects>";
    							 
    			var serializer = new XmlSerializer(typeof(BulkProjectRoot));		
    			var result = (BulkProjectRoot)serializer.Deserialize(new StringReader(xml));			
    			
    			result.Dump();
