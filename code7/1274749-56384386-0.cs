public async Task<byte[]> GetAttachmentAsync(string objectPointer)
{
    var objReq = new GetObjectRequest
    {
        BucketName = "bucket-name",
        Key = objectPointer,    // the file name
    };
    using var objResp = await _s3Client.GetObjectAsync(objReq);
    using var ms = new MemoryStream();
    await objResp.ResponseStream.CopyToAsync(ms, _ct);  // _ct is a CancellationToken
    return ms.ToArray();
}
This won't block any threads while the IO occurs.
