        [HttpGet(nameof(GetBgList))]
        public async Task<IActionResult> GetBgList(string bg)
        {
            return Ok(MessageAlert.DataFound(await _bgService.GetBgList(bg)));
        }
