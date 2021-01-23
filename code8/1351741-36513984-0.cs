    IList<TNotificationEntity> notifications =
        await _notificationsTable.GetRowsByPartitionKeyAndRowKeyAsync(ToTicks(_now), userId, QueryComparisons.GreaterThanOrEqual)
        .ConfigureAwait(false);
    await Task.WhenAll(
        notifications.Select(notification =>
        {
            return Task.Run(async () =>
            {
                await _notificationsTable.DeleteRowAsync(notification.PartitionKey, notification.RowKey).ConfigureAwait(false);
                notification.PartitionKey = ToTicks(utcDateTimeToSend);
                await _notificationsTable.InsertRowAsync(notification).ConfigureAwait(false);
            });
        })).ConfigureAwait(false);
