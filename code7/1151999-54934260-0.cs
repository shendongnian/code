    BlobContinuationToken blobContinuationToken = null;
	do
	{
		var resultSegment = await cloudBlobContainer.ListBlobsSegmentedAsync(prefix: null,
																			 useFlatBlobListing: true, 
																			 blobListingDetails: BlobListingDetails.None,
																			 maxResults: null,
																			 currentToken: blobContinuationToken,
																			 options: null,
																			 operationContext: null);
		// Get the value of the continuation token returned by the listing call.
		blobContinuationToken = resultSegment.ContinuationToken;
		foreach (IListBlobItem item in resultSegment.Results)
		{
			Console.WriteLine(item.Uri);
		}
	} while (blobContinuationToken != null); // Loop while the continuation token is not null.
