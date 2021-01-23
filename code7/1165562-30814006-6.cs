        private async Task PullAssetList()
        {
            await DoPull(tk, "AssetList", _assetMapper.Pull);
            await Task.WhenAll(
                        DoPull(tk, "BlueprintList", _blueprintMapper.Pull),
                        DoPull(tk, "MarketOrders", _orderMapper.Pull),
                        DoPull(tk, "IndustryJobs", _jobMapper.Pull));
        }
        private async Task PullMarketImport()
        {
            await DoPull(tk, "MarketImports", _marketMapper.Pull);
            await DoPull(tk, "WalletTransactions", _transactionMapper.Pull);
        }
        private async Task PullAccountBalance()
        {
            await DoPull(tk, "AccountBalance", _balanceMapper.Pull);
        }
        private async Task Method()
        {
            try
            {
                await Task.WhenAll(PullAssetList(), PullMarketImport(), PullAccountBalance());
            }
            catch (Exception)
            {
                StopSteps(token, _running.ToArray());
            }
            finally { Flush(token); }
        }
