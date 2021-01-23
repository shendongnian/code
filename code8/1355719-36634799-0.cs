    public List<double> MyResults() {
        try {
            return ReadExcelFile();
        }
        finally {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
