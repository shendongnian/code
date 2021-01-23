    public async Task<IResponse> BulkEnrollRequest(EnrollmentRequestDto enrollmentRequest)
        {
            try
            {
                var result = await _bulkEnrollUrl.PostJsonAsync(enrollmentRequest).ReceiveJson<SuccessResponse>();
                return result;
            }
            catch (FlurlHttpTimeoutException)
            {
                throw new AppleTimeOutException();
            }
            catch (FlurlHttpException ex)
            {
                return _errorHandler.DeserializeFlurlException(ex);
            }
        }
