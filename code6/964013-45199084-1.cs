        [HttpPost]
		public async Task<ResponseModel> MyAPI(RequestModel request) {
			try {
				return await RunTask(Action(), Timeout);
			} catch (Exception e) {
				return null;
			}
		}
        private async Task<ResponseModel> Action() {
			return new ResponseModel();
		}
 
