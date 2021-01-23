    public async Task<ActionResult> VersionInfo()
    {
        var version = await _versionInfoViewModelMapper.Map();
        return View(version);...
    }
