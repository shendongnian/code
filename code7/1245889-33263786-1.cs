    _deleteStream
      .Map(selected => new DeleteServerRequest(_serverConfigurationMapper.Map(selected)))
          .Map(req => {
            req.Cancel = DialogResult.Yes != MessageBox.Show("Delete Server?", 
                                                             "Do you want to delete the server?",
                                                               MessageBoxButtons.YesNo));
            return req;
          })
          .Filter(x => !x.Cancel)
          .Publish().RefCount()
          .Subscribe(x => _serverConfigurationRepository.Delete(x.Server));
