            public async Task<TLAbsMessages> Search(TLAbsInputPeer peer, string q, int offset, int limit)
        {
            if (!IsUserAuthorized())
                throw new InvalidOperationException("Authorize user first!");
            var req = new TeleSharp.TL.Messages.TLRequestSearch()
            {
                Peer = peer,
                Q = q,
                Offset = offset,
                Filter = new TLInputMessagesFilterPhotos(),
                Limit = limit
            };
            return await SendRequestAsync<TLAbsMessages>(req);
        }
