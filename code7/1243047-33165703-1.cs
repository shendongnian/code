    public static bool IsInternetConnected() {
        var isInternetConnected = false;
        var connectionProfile = NetworkInformation.GetInternetConnectionProfile();
        if (connectionProfile != null) {
            var connectivityLevel = connectionProfile.GetNetworkConnectivityLevel();
                isInternetConnected = connectivityLevel == NetworkConnectivityLevel.InternetAccess;
        }
        return isInternetConnected;
    }
