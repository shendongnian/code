          string contentType = "application/pdf";
          byte[] bytes = invoice.Data;
          FileContentResult fileResult = new FileContentResult(bytes, contentType);
          fileResult.FileDownloadName = invoice.FileName;
          return fileResult;
