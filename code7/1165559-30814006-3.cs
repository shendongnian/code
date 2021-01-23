        private async Task Method()
        {
            try
            {
                var assetList = DoPull(tk, "AssetList", _assetMapper.Pull)
                    .ContinueWith<Task>(t => Task.WhenAll(
                        DoPull(tk, "BlueprintList", _blueprintMapper.Pull),
                        DoPull(tk, "MarketOrders", _orderMapper.Pull),
                        DoPull(tk, "IndustryJobs", _jobMapper.Pull));
                var marketImport = DoPull(tk, "MarketImports", _marketMapper.Pull)
                    .ContinueWith<Task>(t => DoPull(tk, "WalletTransactions", _transactionMapper.Pull));
                var accountBalance = DoPull(tk, "AccountBalance", _balanceMapper.Pull);
                
                await Task.WhenAll(assetList, marketImport, accountBalance);
            }
            catch (Exception)
            {
                StopSteps(token, _running.ToArray());
            }
            finally { Flush(token); }
        }
