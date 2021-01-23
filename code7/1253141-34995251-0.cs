    blockBlob.DownloadToStream(stream, null, Task.Run(() => GetOptions()).Result);
    private async static Task<BlobRequestOptions> GetOptions()
        {
            var cloudResolver = new KeyVaultKeyResolver(GetToken);
            var rsa = await cloudResolver.ResolveKeyAsync(Config.Get("AzureKeyVault"), CancellationToken.None).ConfigureAwait(false);
            var policy = new BlobEncryptionPolicy(rsa, null);
            return new BlobRequestOptions() { EncryptionPolicy = policy };
        }
