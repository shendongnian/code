    -- To import multiple records into database
    Create PROCEDURE SP_Importimagedata (
     @xmlData XML 
    )
    
    AS
    BEGIN
    	
    	INSERT INTO  [imagedata](
    	ImageID,
    	ImageClippingStatusID,
    	[Priority],
    	UserID,
    	pubid,
    	ClipTypeID
    	)
    
    	SELECT
    	COALESCE([Table].[Column].value('ImageID[1]', 'int'),0) as 'ImageID',
    	[Table].[Column].value('ImageClippingStatusID[1]', 'int') as 'ImageClippingStatusID',
    	[Table].[Column].value(' Priority[1]', 'int') as 'Priority',
    	[Table].[Column].value(' UserID[1]', 'int') as 'UserID',
    	[Table].[Column].value(' pubid[1]', 'int') as 'pubid',
    	[Table].[Column].value(' ClipTypeID[1]', 'int') as 'ClipTypeID'
    	FROM @xmlData.nodes('/Images/Image') as [Table]([Column])
    END
     var response = SearchEngine.Search(objSearchRequest);
    
                if (response.ResponseStatus == SearchResponse.SearchResponseStatus.Success)
                {
                    if (response.SearchResults.Count > 0)
                    {
                        sbCreateDataXml = new StringBuilder();
                        sbCreateDataXml.Append("<Images>");
                        foreach (var item in response.SearchResults)
                        {
                            sbCreateDataXml.Append("<Image>");
                            sbCreateDataXml.Append("<ImageID>" + item.Value.ImageId + "</ImageID>");
                            sbCreateDataXml.Append("<ImageClippingStatusID>" + imageClippingStatusID + "</ImageClippingStatusID>");
                            sbCreateDataXml.Append("<Priority>" + priority + "</Priority>");
                            sbCreateDataXml.Append("<UserID>" + userID + "</UserID>");
                            sbCreateDataXml.Append("<pubid>" + item.Value.PubId + "</pubid>");
                            sbCreateDataXml.Append("<ClipTypeID>" + clipTypeID + "</ClipTypeID>");
                            sbCreateDataXml.Append("</Image>");
                            counter++;
                        }
                        sbCreateDataXml.Append("</Images>");
                        new CommonMethods().InsertImageClippingQueue(sbCreateDataXml.ToString());
                        totalRecordsImported = (int)totalRecordsImported + counter;
                        UpdateClippingSearchKeyword(keywordId, response.TotalAvailableResults, (int)totalRecordsImported);
                    }
                }
