	var sourceContainer = sourceClient.GetContainerReference(containerId);
	var sourceBlob = sourceContainer.GetBlockBlobReference(blobId);
	// Create a policy for reading the blob.
	var policy = new SharedAccessBlobPolicy
	{
		Permissions = SharedAccessBlobPermissions.Read,
		SharedAccessStartTime = DateTime.UtcNow.AddMinutes(-15),
		SharedAccessExpiryTime = DateTime.UtcNow.AddDays(7)
	};
	// Get SAS of that policy.
	var sourceBlobToken = sourceBlob.GetSharedAccessSignature(policy);
	// Make a full uri with the sas for the blob.
	var sourceBlobSAS = string.Format("{0}{1}", sourceBlob.Uri, sourceBlobToken);
	var targetContainer = targetClient.GetContainerReference(containerId);
	await targetContainer.CreateIfNotExistsAsync().ConfigureAwait(false);
	var targetBlob = targetContainer.GetBlockBlobReference(blobId);
	await targetBlob.DeleteIfExistsAsync().ConfigureAwait(false);
	await targetBlob.StartCopyAsync(new Uri(sourceBlobSAS)).ConfigureAwait(false);
