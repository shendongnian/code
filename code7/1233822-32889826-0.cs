                var scanner = new MobileBarcodeScanner();
                scanner.TopText = "Scanning for Barcode...";
                var result = await scanner.Scan(new MobileBarcodeScanningOptions
                {
                    AutoRotate = false
                });
                if (result != null)
                {
                    _scan.ScanValue = result.ToString();
                    _scan.Action = "Scan";
                    await CallService();
                }
                else
                {
                    scanner.Cancel();
                    Recreate();
                }
            };
